#!/bin/bash
# A sample Bash script, by Émile Bossé
DIRECTORY=$1
MESSAGE=$2
echo Hello World!
cd ../"$DIRECTORY"
git status
git add -A
git status
git commit -m "$MESSAGE"