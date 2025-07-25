@echo off
echo Starting port-forward for RabbitMQ...
start cmd /k kubectl port-forward svc/rabbitmq 5672:5672 15672:15672 -n ns-vehicle-management

timeout /t 2 >nul

echo Starting port-forward for PostgreSQL...
start cmd /k kubectl port-forward svc/postgres 5432:5432 -n ns-vehicle-management
