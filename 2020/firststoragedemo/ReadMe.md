## Creating Storage Account

az storage account create --resource-group <YourResourxceGroupName> --kind StorageV2 \
 --sku Standard_LRS --access-tier Cool --name <UniqueStorageAccountName>

az storage account show-connection-string --resource-group <YourResourxceGroupName> \
 --name firststoragedemo17jun --query connectionString

GET https://[url-for-service-account]/?comp=list&include=metadata

https://youraccountname.blob.core.windows.net/?comp=list&include=metadata
