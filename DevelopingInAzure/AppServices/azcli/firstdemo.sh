az webapp list --resource-group rg-az204-demo-001
az webapp list --resource-group rg-az204-demo-001 --query "[?starts_with(name, 'appwebapi')]"
az webapp list --resource-group rg-az204-demo-001 --query "[?starts_with(name, 'appwebapi')].{Name:name}" --output tsv
az webapp deployment source config-zip --resource-group rg-az204-demo-001 --src appwebapi.zip --name appwebapi

az webapp list --resource-group rg-az204-demo-001
az webapp list --resource-group rg-az204-demo-001 --query "[?starts_with(name, 'appwebapp')]"
az webapp list --resource-group rg-az204-demo-001 --query "[?starts_with(name, 'appwebapp')].{Name:name}" --output tsv
az webapp deployment source config-zip --resource-group rg-az204-demo-001 --src appwebapp.zip --name appwebapp

az group delete --name rg-az204-demo-001 --no-wait --yes