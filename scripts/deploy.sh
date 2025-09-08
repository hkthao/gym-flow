#!/bin/bash
set -e

# Set your Docker Hub username or registry URL
DOCKER_REGISTRY="your-docker-registry"

# Log in to Docker Hub (optional, uncomment if needed)
# docker login -u your-username -p your-password

# Build the images first
./build.sh

# Tag and push each service image
docker-compose push

echo "Images pushed to $DOCKER_REGISTRY"

# --- Deployment Section ---
# This is a placeholder for your deployment strategy.
# You might use kubectl, helm, or another tool here.

echo "Deployment script placeholder: You need to implement your deployment logic."

# Example using kubectl:
# echo "Applying Kubernetes manifests..."
# kubectl apply -f infra/kube/

# Example using Helm:
# echo "Deploying with Helm..."
# helm upgrade --install gymflow infra/kube/helm-charts/
