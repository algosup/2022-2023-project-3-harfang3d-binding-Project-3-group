cmake_minimum_required(VERSION 3.0.0)
project(Vectors)
set(CMAKE_CXX_STANDARD 11)

include_directories(..)

set(SOURCES
    ../vector2.cpp
    ../vector3.cpp
)

set(HEADERS
    ../vector2.h
    ../vector3.h
)

add_library(Vectors SHARED ${SOURCES} ${HEADERS})