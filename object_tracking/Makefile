#PKG_CONFIG_PATH=/usr/local/lib/pkgconfig:${PKG_CONFIG_PATH}
#export PKG_CONFIG_PATH

all:
	clang++ -g main.cpp mosquito.cpp -o opencv `pkg-config --cflags --libs opencv` -lmosquittopp

clean:
	rm -rf opencv opencv.dSYM
