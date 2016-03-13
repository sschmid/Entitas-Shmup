#!/bin/sh
xbuild *.sln /verbosity:minimal
if [ $? = 0 ]
then
	mono Assets/Tests/Editor/Libraries/NSpec/NSpecRunner.exe Temp/bin/Debug/Assembly-CSharp-Editor.dll
else
	echo "ERROR: Could not compile!"
	exit 1
fi
