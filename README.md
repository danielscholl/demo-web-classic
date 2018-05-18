# web-demo-classic

This is a sample for writing durable functions  and enabling docker support.

__Requirements:__
- [.Net Core](https://www.microsoft.com/net/download/windows)  (>= 2.1.104)
- [Azure Storage Emulator](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator) (>= 5.3)

## Installation
### Clone the repo

```bash
git clone https://github.com/danielscholl/web-demo-classic.git web-demo-classic
```


### Build and Test the Project on Localhost

1. Build the Project `<ctrl><shift><b>`

1. Test the project `<F5>`


### Create ASM Classic Resources

1. Create a Resource Group

	- Name:  ClassicCommon
	- Location: South Central US

1. Create a Virtual Network (Classic) in the Resource Group - ClassicCommon

	- Name: classicVNet
	- Location: South Central US
	- Address Space:  10.0.0.0/24
	- Subnet Name: MiddleTier
	- Subnet Address Range: 10.0.0.0/27

1.  Create a Virtual Machine (Classic) in the Resource Group - ClassicCommon
	_SQL Server 2016 SP1 Standard on Windows Server 2016_

	- Name: classic-vm
	- Location: South Central US
	- User Name: azureuser
	- Password: **********
	- Size: Standard D1_v2
	- Storage Account: {initials}classic

1. Update the Storage Connection String in WebMVC & WebWorker Role "Settings"  __Cloud__ Configuration

	- Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString: <your_storage_connectionstring>
	- StorageConnectionString: <your_storage_connectionstring>

1. Prepare the Database on the Virtual Machine

	- RDP to the Virtual Machine.   _Note: You might have to apply the [RDP Fix](https://justinho.com/blog/2018/05/09/CredSSP.html)_  
	- Enable Mixed Mode Authentication
	- Add a SQL Server User: 'azureuser'
	- Connect as azureuser
	- Create a Database  name:db
	- Open Firewall Rule for 1433

1. Update the DB Connection WebWorker Role "Settings" __Cloud__ Configuration and WebMVC/Web.Release.config

	- AdsDbConnectionString: <your_db_connectionstring>

1. Update the DB Connection for WebMVC in Web.Release.config

	- AdsContext: <your_db_connectionstring>

1. Publish the Cloud Serivce "ClassicWeb"
	- ServiceLabel: ClassicCommon
	- ServiceName: classiccommon
	- Storage Account: <your_storageaccount>

