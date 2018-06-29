#!/bin/bash

# 1 paramètre correspond au nom actuel de l'élément
# 2 paramètre correspond au nouveau nom pour l'élément

OLD_NAME=$1
NEW_NAME=$2

cp $OLD_NAME $NEW_NAME
rm $OLD_NAME