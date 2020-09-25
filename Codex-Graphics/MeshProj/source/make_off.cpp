#define _USE_MATH_DEFINES
#include "App.h"

#include <iostream>
#include <fstream>
#include <cmath>
#include <iomanip>

using namespace std;

void App::makeCylinder()
{
    msgBox("Generating Cylinder");
    char name[] = "D:\\WORKING FOLDER\\3D-Graphics-Shaders\\Codex-Graphics\\MeshProj\\data-files\\model\\cylinder.off";
    writeFile(name, m_col, m_row, true, "");
    ArticulatedModel::clearCache();
    loadScene("Cylinder");
}

void App::makeTerrain(G3D::String m_image)
{
    shared_ptr< G3D::Image> image = G3D::Image::fromFile(m_image);
    int h = image->height(), w = image->width();
    int resol = floor(m_ratio * 0.2);
    char yName[] = "D:\\WORKING FOLDER\\3D-Graphics-Shaders\\Codex-Graphics\\MeshProj\\data-files\\model\\color.txt";
    ofstream out(yName);
    if (!out)
    {
        cout << "File Cannot be written";
        return;
    }
    m_row = m_col = floor(h / resol);
    for (int i = 0; i < m_row ; i++)
    {
        for (int j = 0; j <m_col; j++)
        {
            int ii = i==m_row? w-1: resol * i;
            int jj = j==m_col? h-1: resol * j;

            Point2int32 pos(ii, jj);
            Color4 color;
            image->get(pos, color);
            float c = color.r;
            out << c << endl;

        }
    }
    if (out.is_open()) out.close();
    msgBox("Generating Terrain");
    char name[] = "D:\\WORKING FOLDER\\3D-Graphics-Shaders\\Codex-Graphics\\MeshProj\\data-files\\model\\terrain.off";

    writeFile(name, m_col, m_row, false, yName);
    ArticulatedModel::clearCache();
    loadScene("Terrain");
}

void App::writeFile(const char* name, float& c, float& r, bool isCylinder, const char* yName)
{
    ofstream out(name);
    if (!out)
    {
        cout << "File Cannot be written";
        return;
    }

    ifstream in(yName);
    if (!isCylinder)
    {
        if (!in)
        {
            cout << "Height File cannot be opened";
            return;
        }
    }

    out << "OFF" << endl;
    char* comment = isCylinder ? "#cylinder" : "#terrain";
    out << comment << endl;

    char space = ' ';

    int row = (int) r, col = (int) c;

    //vertex, triangles, bottomcenter, topcenter
    int v = (row + 1) * (col + 1) + 2, t = 2 * row * col + col * 2, bc, tc; 
    if (!isCylinder)
    {
        v = v - 2;
        t = t - col * 2;
    }

    vector3 vert;
    double degi = isCylinder? 2 * M_PI / col: 0, deg;
    double radius = 0.2;

    int edge = t * 3 - (col + 1) - (row * col) - (t / 2);
    out << v << space << t << space << edge << endl;

    int vi = 0;
    float y = 0;
    for (int i = 0; i <= row ; ++i)
    {
        for (int j = 0; j <= col ; ++j)
        {
            if (j == col || j == 0)
                deg = 0;
            vert.x = isCylinder? cos(deg) * radius : radius * i;
            if (!isCylinder)
                in >> y;
            vert.y = isCylinder ? i*radius : y*radius;
            vert.z = isCylinder ? sin(deg) * radius: radius * j;
            out << vert.x << space << vert.y << space << vert.z << endl;
            deg += degi;
            vi++;
        }
    }

    if (isCylinder)
    {
        bc = vi;
        //center bottom
        vert.x = 0;
        vert.y = 0;
        vert.z = 0;
        out << vert.x << space << vert.y << space << vert.z << endl;
        vi++;

        tc = vi;
        //centerTop
        vert.x = 0;
        vert.y = radius * row;
        vert.z = 0;
        out << vert.x << space << vert.y << space << vert.z << endl;
    }

    int three = 3, t1, t2, t3, t4, t5, t6;
    for (int i = 0; i < row; ++i)
    {
        for (int j = 0; j < col; ++j)
        {

            t1 = (col + 1) * (i) + j + 1;
            t2 = (col + 1) * (i) + j;
            t3 = (col + 1) * (i + 1) + j;

            t4 = t3;
            t5 = t4 + 1;
            t6 = t1;

            if (isCylinder)
            {
                out << three << space << t1 << space << t2 << space << t3 << endl;
                out << three << space << t4 << space << t5 << space << t6 << endl;
            }
            else
            {
                out << three << space << t3 << space << t2 << space << t1 << endl;
                out << three << space << t6 << space << t5 << space << t4 << endl;
            }
        }
    }

    if (isCylinder)
    {
        int i = 1;
        for (int j = 0; j < col; j++)
        {
            out << three << space << i << space << bc << space << i - 1 << endl;
            i++;
        }

        i = vi - 2;
        for (int j = 0; j < col; j++)
        {
            out << three << space << i - 1 << space << tc << space << i << endl;
            i--;
        }
    }

    if (out.is_open()) out.close();
        
}