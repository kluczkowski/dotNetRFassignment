FROM alpine
WORKDIR ./app/my-app

RUN apk add --update nodejs npm && npm install npm@latest -g

CMD npm install && npm run build && npm start
