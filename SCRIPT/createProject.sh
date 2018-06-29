#!/bin/bash
PROJECT_TYPE=$1
PROJECT_NAME=$2

if [ $PROJECT_TYPE == "SCRIPT" ]
then
    cp -r IotProjectTemplate ../SCRIPT/"$PROJECT_NAME"
elif [ $PROJECT_TYPE == "IOT_CODE" ]
then
    cp -r ScriptProjectTemplate ../IOT_CODE/"$PROJECT_NAME"
elif [ $PROJECT_TYPE == "DATABASE" ]
then
    cp -r DatabaseProjectTemplate ../DATABASE"$PROJECT_NAME"
else
    echo "the type doesn't correspond to any real type"
fi