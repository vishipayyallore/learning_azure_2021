# Main Title

## Sub-Title

az account list --output table
az account set --subscription "Guid"

## Retrieve the Resource Groups

az group list --output table

## Retrieve the Resources with the Resource Group

az resource list --resource-group Learn-d832bdd3-6e83-4604-ab57-9239e6ac48ca --resource-type Microsoft.Web/sites

Output
[
  {
    "id": "/subscriptions/Guid/resourceGroups/Learn-d832bdd3-6e83-4604-ab57-9239e6ac48ca/providers/Microsoft.Web/sites/firstwordpress2009",
    "identity": null,
    "kind": "app",
    "location": "centralus",
    "managedBy": null,
    "name": "firstwordpress2009",
    "plan": null,
    "properties": null,
    "resourceGroup": "Learn-d832bdd3-6e83-4604-ab57-9239e6ac48ca",
    "sku": null,
    "tags": null,
    "type": "Microsoft.Web/sites"
  }
]

## To Stop the WebSite

az webapp stop --id "/subscriptions/Guid/resourceGroups/Learn-d832bdd3-6e83-4604-ab57-9239e6ac48ca/providers/Microsoft.Web/sites/firstwordpress2009"

## To Start the WebSite

az webapp start --id "/subscriptions/Guid/resourceGroups/Learn-d832bdd3-6e83-4604-ab57-9239e6ac48ca/providers/Microsoft.Web/sites/firstwordpress2009"
