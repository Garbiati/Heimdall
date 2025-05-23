# Heimdall

Authentication and authorization service for a multi-tenant telemedicine platform.

## Overview

Heimdall is the identity and access management service for a distributed telemedicine system, built to support multiple roles such as:

- Administrators
- Doctors
- Patients
- Receptionists

This service is designed to be scalable, secure, and cloud-ready using Keycloak for identity management.

## Tech Stack

- Keycloak 24+ (Quarkus-based)
- PostgreSQL
- Docker & Docker Compose

## Getting Started

### 1. Clone the repository

git clone git@github-personal:Garbiati/Heimdall.git
cd Heimdall

### 2. Configure environment

Create a copy of the .env.example file:

cp .env.example .env

Update the values as needed.

### 3. Run the stack

docker compose up -d

### 4. Access Keycloak

Once the services are up, go to:

http://localhost:8080
Default credentials (from .env):

- Username: admin
- Password: admin

## Folder Structure

Heimdall/
├── docker-compose.yml       # Docker config for Keycloak + Postgres
├── .env.example             # Example environment file
├── .gitignore               # Git ignore file
└── keycloak/
    └── themes/              # (Optional) Custom Keycloak themes

## License

This project is licensed under the MIT License - see the LICENSE file for details.
