#!/bin/sh

if [ "$NODE_ENVIRONMENT" = "Development" ]; then
  echo "Running in development mode..."
  exec npm run dev
else
  echo "Running in production mode..."
  exec npm start
fi
