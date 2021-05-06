SubscriptionName="Visual Studio Professional Subscription"
RGName="rg-az204-arm-azubuntu-dev-001"
LocationName="EastUS"
BaseName="vmapr2021"
VmName="simpleLinuxVM2" 
PortToOpen=80
username="demouser"
ImageName="UbuntuLTS" 

 #use this command when you need to create a new resource group for your deployment
az group create --name $RGName --location $LocationName
az group list --output table

##### Deploy the VM
az deployment group create --resource-group $RGName --template-file ./ubuntuvm.deploy.json --parameters ./ubuntuvm.parameters.json

##### Opending the ports
az vm open-port --resource-group $RGName --name $VmName --port $PortToOpen --priority 900

##### IP Addresses for Remote Access
az vm list-ip-addresses --resource-group $RGName --name $VmName --output table

ssh -i ./id_rsa demouser@13.82.71.166

##### From within the Ubuntu VM

##### DEMO 1
sudo apt update && sudo apt install -y lamp-server^
logout

##### DEMO 2
sudo apt-get -y update
sudo apt-get -y install nginx
logout

##### View the site.
http://13.82.71.166