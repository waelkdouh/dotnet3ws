# Simple Dockerfile for NodeJS  

FROM node:boron

LABEL author="sampleauthor@contoso.com" 

# Create app directory
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Install app dependencies
COPY package.json .
RUN npm install

# Bundle app source
COPY . .

EXPOSE 8080

CMD [ "npm", "start" ]