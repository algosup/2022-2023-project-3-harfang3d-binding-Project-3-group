cmake_minimum_required(VERSION 3.0.0)
project(2022-2023-project-3-harfang3d-binding-Project-3-group VERSION 0.1.0)

include(CTest)
enable_testing()

add_library(2022-2023-project-3-harfang3d-binding-Project-3-group 2022-2023-project-3-harfang3d-binding-Project-3-group.cpp)

set(CPACK_PROJECT_NAME ${PROJECT_NAME})
set(CPACK_PROJECT_VERSION ${PROJECT_VERSION})
include(CPack)
