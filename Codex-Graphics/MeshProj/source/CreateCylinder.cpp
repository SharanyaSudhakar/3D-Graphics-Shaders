#pragma once

#define _USE_MATH_DEFINES
#include "create_mesh.h"

#include <iostream>
#include <cmath>
#include <iomanip>

using namespace std;

/*
* Writes the dimensions of the mesh. vertex and tricounts
*/
void myMesh::Cylinder::writeDimensions()
{
    //+2 for the top and bottom center vertices.
    //col*2 for the top and bottom cap triangles
    int v = (row + 1) * (col + 1) + 2, t = 2 * row * col + col * 2;

    double degi = M_PI / col, deg;
    double radius = 0.1;

    int edge = t * 3 - (col + 1) - (row * col) - (t / 2);
    out.open(filepath,ios_base::app);
    out << "OFF" << endl;
    out << "#cylinder" << endl;
    out << v << space << t << space << edge << endl;
    out.close();
}

/*
* Write the vertex postion of the mesh to the .off file
* the cylinder radius is standard set to 0.2
*/
void myMesh::Cylinder::writeVertices()
{
    double x, y, z;
    double degi = 2 * M_PI / col, deg;
    double radius = 0.2;

    out.open(filepath, ios_base::app);
    for (int i = 0; i <= row; ++i)
    {
        for (int j = 0; j <= col; ++j)
        {
            if (j == col || j == 0)
                deg = 0;
            x = cos(deg) * radius;
            y = i * radius;
            z = sin(deg) * radius;
            out << x << space << y << space << z << endl;
            deg += degi;
            vi++;
        }
    }

    //bottom center
    out << 0 << space << 0 << space << 0 << endl;
    vi++;
    out << 0 << space << radius * row << space << 0 << endl;
    vi++;
    out.close();
}

void myMesh::Cylinder::writeTriangles()
{
    int t1, t2, t3, t4, t5, t6;
    out.open(filepath, ios_base::app);
    int bc = vi - 2, tc = vi - 1;
    for (int i = 0; i < row; ++i)
    {
        for (int j = 0; j < col; ++j)
        {

            t1 = (col + 1) * (i)+j + 1;
            t2 = (col + 1) * (i)+j;
            t3 = (col + 1) * (i + 1) + j;

            t4 = t3;
            t5 = t4 + 1;
            t6 = t1;

            out << three << space << t1 << space << t2 << space << t3 << endl;
            out << three << space << t4 << space << t5 << space << t6 << endl;
        }
    }

    //bottom base triangles
    int i = 1;
    for (int j = 0; j < col; j++)
    {
        out << three << space << i << space << bc << space << i - 1 << endl;
        i++;
    }

    //top triangles
    i = vi - 3;
    for (int j = 0; j < col; j++)
    {
        out << three << space << i - 1 << space << tc << space << i << endl;
        i--;
    }
    out.close();
}

void myMesh::WineGlass::writeVertices()
{
    double x, y, z;
    double degi = 2 * M_PI / col, deg;
    int dist,color;

    double radius, height;

    ifstream in(wineglassRadiiPath);
    out.open(filepath, ios_base::app);
    int maxrow = (int)(row / 3);
    for (int i = 0; i <= row; ++i)
    {
        in >> radius >> height;
        for (int j = 0; j <= col; ++j)
        {
            if (j == col || j == 0)
                deg = 0;
            x = cos(deg) * radius;
            y = height;
            z = sin(deg) * radius;
            out << x << space << y << space << z << endl;
            deg += degi;
            vi++;
        }
    }
    in >> radius >> height;
    //bottom center
    out << 0 << space << 0 << space << 0 << endl;
    vi++;

    //top Center
    out << 0 << space << height << space << 0 << endl;
    vi++;
    out.close();
}