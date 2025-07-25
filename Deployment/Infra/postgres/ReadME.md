Apply this YAML with:
kubectl apply -f postgres-k8s.yaml -n ns-vehicle-management

Connect to PostgreSQL inside your cluster via postgres:5432 using credentials from env vars.

✅  Access from inside the cluster
psql -h postgres-0.postgres -U admin -d vehicle_management

✅  Access from your host (optional: port-forward)
kubectl port-forward svc/postgres 5432:5432 -n ns-vehicle-management

✅ Step 1: Delete the StatefulSet (not the PVC)
kubectl delete statefulset postgres -n ns-vehicle-management

✅ delete all
kubectl delete pvc -n ns-vehicle-management --all

✅ get all post status 
kubectl get pods -n ns-vehicle-management

✅ get service
kubectl describe svc postgres -n ns-vehicle-management

✅ get service details
postgres-0.postgres.ns-vehicle-management.svc.cluster.local

Get Logs
kubectl logs -n ns-vehicle-management -l app=postgres

remove stateful
kubectl delete statefulset postgres -n ns-vehicle-management --cascade=orphan
kubectl delete service postgres-headless -n ns-vehicle-management
remove service
kubectl delete service postgres -n ns-vehicle-management

