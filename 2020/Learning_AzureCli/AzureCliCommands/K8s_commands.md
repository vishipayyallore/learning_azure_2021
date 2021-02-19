# Kubernetes Related Commands 

kubectl get all
kubectl apply -f k8s/deployment.yml
kubectl get services -w

## Retrieve

kubectl get pods -n your-namespace
kubectl get services -n your-namespace
kubectl get statefulsets -n your-namespace

## Delete

kubectl delete services your-service-name -n your-namespace
kubectl delete statefulsets your-service-name -n your-namespace
