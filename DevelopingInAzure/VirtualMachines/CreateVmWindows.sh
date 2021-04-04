az group list

az group create --name "YourRGName" --location "eastus"

az vm create --resource-group "YourRGName" --name azvmtwo --image win2016datacenter --admin-username demouser 
