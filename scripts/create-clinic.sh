#!/bin/bash

# Inputs
CLINIC_NAME=$1
REALM_NAME="clinic-${CLINIC_NAME// /-}" # replace spaces with dashes

# Load credentials from environment variables
KEYCLOAK_USER=${KEYCLOAK_USER:-admin}
KEYCLOAK_PASS=${KEYCLOAK_PASS:-admin}

# Get Access Token
ACCESS_TOKEN=$(curl -s \
  -d "client_id=admin-cli" \
  -d "username=$KEYCLOAK_USER" \
  -d "password=$KEYCLOAK_PASS" \
  -d "grant_type=password" \
  "http://localhost:8080/realms/master/protocol/openid-connect/token" \
  | jq -r '.access_token')

# Clone template and replace realm name
cp keycloak/import/realm-template.json scripts/temp-realm.json
sed -i "s/\"realm\": \".*\"/\"realm\": \"$REALM_NAME\"/" scripts/temp-realm.json

# Create Realm
curl -s -X POST "http://localhost:8080/admin/realms" \
  -H "Authorization: Bearer $ACCESS_TOKEN" \
  -H "Content-Type: application/json" \
  --data @scripts/temp-realm.json

rm -f scripts/temp-realm.json scripts/clean-realm.json

echo "✅ Realm '$REALM_NAME' created successfully."