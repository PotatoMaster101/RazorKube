# Razor Kubernetes
A sample Razor Pages application to demonstrate hosting a webapp on Kubernetes.

## Deploying Locally via `docker`
Use `docker compose` to build and run the webapp:
```
$ cd RazorKube
$ docker compose up --build -d
```
Visit the site via `http://localhost:8080`.

## Deploying Locally via `kubectl`
Build the webapp image locally:
```
$ cd RazorKube
$ docker build . -t potatomaster101/razorkube --no-cache
```

Deploy onto local Kubernetes:
```
$ kubectl apply -f .k8s/web/
$ kubectl apply -f .k8s/db/
```
Visit the site via `http://localhost`.

## TODO
- Investigate where did K8s write the volume on Windows host
- Configure HTTPS
