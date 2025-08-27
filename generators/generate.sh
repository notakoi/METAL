#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR"

if [ ! -f "generators.csproj" ]; then
    dotnet new classlib --force
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
    rm Class1.cs
fi


for CONFIG_FILE in dbs/*.sh; do
    source "$CONFIG_FILE"

    rm -rf "$DIR" 
    mkdir -p "$DIR"
    
    CONNECTION="Host=${PG_HOST};Port=${PG_PORT};Database=${PG_DB};Username=${PG_USER};Password=${PG_PASSWORD}"
    dotnet ef dbcontext scaffold "$CONNECTION" "$PROVIDER" --output-dir "$DIR" 
done
