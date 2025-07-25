build image
docker build -t vehicle-service:latest -f Services/VehicleService/VehicleService.API/Dockerfile .


Kubectl apply -f vehicle-service.yaml -n ns-telematics-system

docker hub steps

### tag the image
docker tag vehicle-service:latest naushad79/vehicle-service:latest

### push the image to docker hub
docker push naushad79/vehicle-service:v1
