FROM node:18
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
EXPOSE 5173
ENV NODE_ENVIRONMENT=Production
ENV REACT_APP_API_BASE_URL=http://localhost:5000

# Use shellscript to automatically toggle between npm run dev or npm start depending on environment
COPY entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

CMD ["/entrypoint.sh"]