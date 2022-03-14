# Adactin Insurance Web API

This repository contains ASP.NET Core 6 API which serves for front-end app [adactin-premium-calc](https://github.com/zinduyaar/adactin-premium-calc).

See the endpoints here: 

## Endpoints

## Calculate death premium (HTTP POST)

``` https://localhost:7254/api/premium/calculate ```

```javascript
  {
    "fullName": "string",
    "age": 0,
    "occupationId": 0,
    "deathSumAssured": 0
  }
```

