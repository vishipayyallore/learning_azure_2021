# Variables
$SubscriptionName = "Visual Studio Professional Subscription"
$RGName = "rg-az204-azubuntu-dev-001"
$LocationName = "EastUS"
$BaseName = "vmapr2021"
$VmName = "ubuntu$($BaseName)" ##### Windows computer name cannot be more than 15 characters long
$PortToOpen = 80
$username = "demouser"
$ImageName = "UbuntuLTS" 

##### Login
az login
az account set --subscription $SubscriptionName
az account list --output table
az account show

###### Group
az group list --output table
az group create --name $RGName --location $LocationName

##### Virtual Machine
az vm create --resource-group $RGName --name $VmName --image $ImageName --admin-username $username --authentication-type ssh --ssh-key-value C:\Users\PK.Viswanatha-Swamy\.ssh\id_rsa.pub
az vm create --resource-group $RGName --name $VmName --image $ImageName --admin-username $username --authentication-type ssh --ssh-key-value ~/.ssh/id_rsa.pub

##### Opending the ports
az vm open-port --resource-group $RGName --name $VmName --port $PortToOpen --priority 900

##### IP Addresses for Remote Access
az vm list-ip-addresses --resource-group $RGName --name $VmName --output table

##### Login into VM
ssh demouser@PublicIpAddress
ssh -i ~/.ssh/id_rsa demouser@PublicIpAddress #From Ubuntn VM (Private Key)

##### From within the Ubuntu VM
sudo apt-get -y update
sudo apt-get -y install nginx

##### Remove the Resource Group
az group delete --name $RGName
