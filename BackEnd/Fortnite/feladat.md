
# 1. Feladat

- Készíts egy ``authRoutes`` nevű file-t a [routes](./api/routes/) mappában
- Az [app.js](./app.js) fileban kösd össze a ``/api`` útvonalakhoz az [authRoutes](./api/routes/authRoutes.js) routert
- Az ``authRoutes.js`` routerben hozd létre az alábbi endpointokat:
    - **(POST)** ``/login``
    - **(GET)** ``/status``
    - **(DELETE)** ``/logout``

---

# 2. Feladat

- Készíts egy ``errorHandler.js`` nevű middlewaret a [middlewares](./api/middlewares) mappában

# 3. Feladat

- Állítsd be a [server.js](./server.js) fileban azt, hogy használni tudjuk a [.env](./.env) file konstans értékeit
- Készíts a [db](./api/db/) mappában egy ``index.js`` nevű file-t, amiben:
    - Minden adatot a .env fileban találsz
    - Csatlakozol az adatbázisra
    - Teszteled a kapcsolatot (+ hibakezelés)
    - 

    # 4. Feladat

- Minden model a ``Model`` osztályból öröklődjön.
- Készíts egy ``Setting`` modellt, amiben tárolod a felhasználó beállításait. Legyenek ezek a beállítások bármilyenek
- Készíts egy ``Weapon`` modellt a [models](./api/models/) mappában, ahol tetszőleges oszlopokkal inicializálod a modellt.

<!-- Eddig kész -->

# 5. Feladat

- Add vissza az összes modellt egy objektumban.
- Kapcsold össze a modelleket az [index.js](./api/models/index.js) fileban.