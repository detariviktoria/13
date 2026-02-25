@echo off

echo Installing dependencies...

call npm install

start "Tests" cmd /k "npm test"

start "Server" cmd /k "npm start"