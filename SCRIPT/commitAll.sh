#!/bin/bash

# 1 paramètre correspond à SCRIPT, DATABASE, IOT_CODE
# 2 paramètre correspond au nom du dossier de projet que l'on veut commiter
# 3 paramètre correspond au message que l'on veut mettre dans le commit

# A sample Bash script, by Émile Bossé
PROJECT_TYPE=$1
DIRECTORY=$2
MESSAGE=$3
echo Hello World!
cd ../"$PROJECT_TYPE"/"$DIRECTORY"
git status
git add -A
git status
git commit -m "$MESSAGE"