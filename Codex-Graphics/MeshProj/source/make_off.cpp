#define _USE_MATH_DEFINES
#include "App.h"
#include "create_mesh.h"
#include <iostream>
#include <fstream>
#include <cmath>
#include <iomanip>

using namespace std;

void App::makeCylinder()
{
    char name[] = "D:\\WORKING FOLDER\\3D-Graphics-Shaders\\Codex-Graphics\\MeshProj\\data-files\\model\\cylinder.off";
    myMesh::Cylinder cyl("Generating Cylinder", name, (int)cylinder_col, (int)cylinder_row);
    cyl.initMesh();
    loadScene("Cylinder");
}

void App::makeTerrain(G3D::String m_image)
{
    //terrain loc
    char name[] = "D:\\WORKING FOLDER\\3D-Graphics-Shaders\\Codex-Graphics\\MeshProj\\data-files\\model\\terrain.off";

    myMesh::Terrain terr("Generating Terrain", name, (int)terrain_row_col, (int)terrain_row_col, m_image, terrain_px_per_m, terrain_max_height);
    terr.initMesh();
    loadScene("Terrain");
}

void App::makeWineGlass(G3D::String m_image)
{
    //terrain loc
    char name[] = "D:\\WORKING FOLDER\\3D-Graphics-Shaders\\Codex-Graphics\\MeshProj\\data-files\\model\\wineglass.off";

    myMesh::WineGlass glass("Generating WineGlass", name, (int)wineglass_col, (int)wineglass_row, m_image);

    glass.initMesh();
    loadScene("WineGlass");
}