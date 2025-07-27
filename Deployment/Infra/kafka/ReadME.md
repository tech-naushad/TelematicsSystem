kubectl delete service kafka -n ns-infra
kubectl delete statefulset kafka -n ns-infra
kubectl delete pvc -l app=kafka -n ns-infra  # optionally delete PVCs for Kafka data

kubectl apply -f kafka.yaml -n ns-infra

kubectl logs -n ns-infra kafka-0

kubectl get pods -n ns-infra