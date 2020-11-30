#pragma once

#define _USE_MATH_DEFINES
#include "create_mesh.h"

#include <iostream>
#include <cmath>
#include <iomanip>

using namespace std;

void myMesh::Terrain::writeDimensions()
{
    int v = (row + 1) * (col + 1), t = 2 * row * col;
    int edge = t * 3 - (col + 1) - (row * col) - (t / 2);
    out.open(filepath, ios_base::app);
    out << "OFF" << endl;
    out << "#terrain" << endl;
    out << v << space << t << space << edge << endl;
    out.close();
}

void myMesh::Terrain::writeVertices()
{
    int vi = 0, ci=0;
    double x, y, z;
    float _y;
    ifstream in(terrainHeightPath);
    out.open(filepath, ios_base::app);
    for (int i = 0; i <= row; ++i)
    {
        for (int j = 0; j <= col; ++j)
        {
            x = segWidth * i;
            in >> _y;
            y = _y * maxHeight;
            z = segHeight * j;
            out << x << space << y << space << z << endl;
            vi++;
        }
    }

    out.close();
    if (in.is_open()) in.close();
}

void myMesh::Terrain::writeTriangles()
{
    int t1, t2, t3, t4, t5, t6;
    out.open(filepath, ios_base::app);
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

            out << three << space << t3 << space << t2 << space << t1 << endl;
            out << three << space << t6 << space << t5 << space << t4 << endl;
        }
    }
    out.close();
}