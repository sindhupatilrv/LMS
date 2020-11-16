Feature: EnrollWindowModern
	Enroll a Window Modern device and assign a profile after upgrade 
# Please copy the feature file into Master BDD solution inorder to execute, if 
# execute it here, it will fail 
Background: 
	Given I am a user with name '{Administrator}'
	And I created WNS connection
	And I am '{apiclient}' making calls on behalf of '{administrator}'

@BeforeUpgrade
Scenario Outline: 1.1 Enroll - [Modern Desktop] before upgrade
	Given I have created device groups with properties as follows:
		| Name                        | Kind    | Icon   | Path               |
		| autogenerate <DeviceGroup1> | Regular | Yellow | \\\\<DeviceGroup1> |
	And I am a system administrator with following Windows Modern devices enrolled:
		| OsVersion     | Platform            | DeviceId                | DeviceName                | DevicePath         |
		| 10.0.14393.11 | Windows10DesktopRs1 | autogenerate <DeviceId> | autogenerate <DeviceName> | \\\\<DeviceGroup1> |
	
	Examples:
		| DeviceGroup1                   | DeviceGroup2                   | DeviceFamily | DeviceId                | DeviceName                    |
		| UpdradeTaskDeviceGroup1.{guid} | UpdradeTaskDeviceGroup2.{guid} | WindowsPhone | UpgradeDeviceId1.{guid} | UpgradeTaskDeviceName1.{guid} |

@AfterUpgrade
Scenario Outline: 2.4 Create a profile [Modern Desktop] and assigned to before enrolled device 
	Given I have set Windows Modern Profile 'autogenerate <Profile>' of type '<ProfilePayloadType>' as follows:
		| SSID           | PrivateNetwork  | ConnectionType   | PhysicalNetworkType   | ConnectionMode   | SecurityMode |
		| SOTI Open WiFi | <HiddenNetwork> | <ConnectionType> | <PhysicalNetworkType> | <ConnectionMode> | none         |
	And I have created and saved Windows Modern Profile as follows:
		| ProfileId | ProfilePayloadType   | DeviceFamily   | DeviceFamilyQualification   | Path              |
		| <Profile> | <ProfilePayloadType> | <DeviceFamily> | <DeviceFamilyQualification> | \\\\<DeviceGroup> |
	And Profile '<Profile>' version '1' with type '<ProfilePayloadType>' is successfully saved with all parameters specified in the scenario
	
	When Await for profile recalculation and Device checks in as follows:
		| ProfileId | DeviceId   |
		| <Profile> | <DeviceId> |
	Then The statuses of the device profiles are as follows:
		| ProfileName | DeviceId   | Status    | Version |
		| <Profile>   | <DeviceId> | Installed | 1       |
	And New log entries are added for device with id '<DeviceId>':
		| LogMessage                 | EventSeverity | LogDetails             | Message                                                 |
		| DeviceConfigurationSuccess | Information   | Wireless Configuration | Device Configuration installed (Wireless Configuration) |
		| DeviceProfileInstalled     | Information   |                        | Profile "<Profile>" version 1 installed                 |

	Examples:
		| DeviceGroup                    | DeviceFamily | OSVersion     | DeviceId                | DeviceName                    | Platform            | Profile                   | ProfilePayloadType | HiddenNetwork | ConnectionType | ConnectionMode | DeviceFamilyQualification | PhysicalNetworkType |
		| UpdradeTaskDeviceGroup1.{guid} | WindowsPhone | 10.0.14393.11 | UpgradeDeviceId1.{guid} | UpgradeTaskDeviceName1.{guid} | Windows10DesktopRs1 | UpgradeWifiProfile.{guid} | Wifi               | False         | IBSS           | manual         | Windows10Desktop          | g                   |