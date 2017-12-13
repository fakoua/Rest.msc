# Rest.msc
Restful API management for Windows Services. Access and control windows services using http commands.

## Getting Started

- Download the latest Release binary from: [Latest Release](https://github.com/fakoua/Rest.msc/releases)
- Check the file **Rest.msc.exe.config** (Set ApiKey to empty if you want to disable the authentication)
- Run the file **Rest.msc.exe** AS ADMINISTRATOR
- From any browser open (http://localhost:9000/swagger/ui/index) to see swagger api docs (Make sure APIKey is empty)
- From any browser open (http://localhost:9000/api/Services/Get?api_key=111) to get the list of services on the machine.

## Install Rest.msc As Service

- Run the command line AS ADMINISTRATOR
- Go the Rest.msc folder and run the command **Rest.msc.exe install**
- Go to the service manager (services.msc) find the service **Rest.msc API** and Start the service
- Now you can access the API using any Restful Client
- *for complete documentation, keep reading this file!*

### Prerequisites

.Net Framework 4.7, Visual Studio 2015 or higher with Visual Basic.Net

## Authors

* **Sameh Fakoua** - [fakoua](https://github.com/fakoua)

## License

This project is licensed under the MIT License.
