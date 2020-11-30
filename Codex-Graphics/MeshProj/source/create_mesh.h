#pragma once
#include <G3D/G3D.h>
#include <fstream>
#include <cmath>

namespace myMesh {

    /*
    * Abstract class to create meshes that can be written to and read from an .off file
    */
    class Mesh
    {
    protected:
        char *msg, *filepath;
        int col, row;
        const int three = 3;
        int vi; //vertex index
        std::ofstream out;

    public:
        const char space = ' ';

        /*
        * This method displays a message box, calls the create mesh
        * method, will clear cache and return the scene name to be loaded.
        */
        virtual void initMesh()
        {
            //set col and row and name properties
            msgBox(msg);
            createMesh();
            ArticulatedModel::clearCache();
        };

        /*
        * This method is a parent method that can be overriden by child methods if necessary, if not they have a default implementation where each of the mesh creation methods are called in order so that the .off file can be written and read back to produce the mesh.
        */
        virtual void createMesh()
        {
            writeDimensions();
            writeVertices();
            writeTriangles();
        };

        virtual void writeDimensions() = 0;
        virtual void writeVertices() = 0;
        virtual void writeTriangles() = 0;

        /*
        * Constructor
        * m(char*) mesage to be displayed
        * fp(char*) filepath of the .off file
        * c(int) columns of the mesh
        * r(int) rows of the mesh
        */
        Mesh(char* m, char* fp, int c, int r) :
            msg(m), filepath(fp), col(c), row(r), out(fp)
        {
            out.close();
            vi = 0;
        };
    };

    class Cylinder : public Mesh
    {
    public:
        Cylinder(char* msg, char* filepath, int col, int row) : Mesh(msg,filepath,col,row) {};
        void writeDimensions();
        void writeVertices();
        void writeTriangles();
    };

    class WineGlass : public Cylinder
    {
    private:
        char *wineglassRadiiPath;
        double segw, segh;
        int maxrow;
    public:
        WineGlass(char* msg, char *filepath, int col, int row, G3D::String img) :Cylinder(msg, filepath, col, (int)(row*1.5))
        {
            maxrow = row;
            wineglassRadiiPath = "D:\\WORKING FOLDER\\3D-Graphics-Shaders\\Codex-Graphics\\MeshProj\\data-files\\model\\radii.txt";
            //calculateRadius(img);
        };

        void calculateRadius(G3D::String imagePath)
        {
            shared_ptr<G3D::Image> image = G3D::Image::fromFile(imagePath);
            int h = image->height(), w = image->width();
            segw = w / col;
            segh = h / maxrow;

            double radius = 0, height=0;
            out.open(wineglassRadiiPath);
            for (int i = maxrow; i > 0; --i)
            {
                for (int j = 0; j <= col; j++)
                {
                    int x = j == col ? (w-1) : floor(segw * j);
                    int y = i == maxrow ? (h-1) : floor(segh * i);

                    Point2int32 pos(x,y);
                    Color4 color;
                    image->get(pos, color);
                    if (color.r > 0.9)
                    {
                        radius = (double)x/100;
                        height = (double)abs(y - h) / 100;
                        break;
                    }
                }
                //redline wont have a zero radius.
                if (radius != 0)
                    out << radius << space << height << std::endl;
                radius = 0;
            }

            for (int i = 1; i <= maxrow/2; ++i)
            {
                for (int j = 0; j <= col; j++)
                {
                    int x = j == col ? (w - 1) : floor(segw * j);
                    int y = j == maxrow ? (h - 1) : floor(segh * i);

                    Point2int32 pos(x, y);
                    Color4 color;
                    image->get(pos, color);
                    if (color.r > 0.9)
                    {
                        radius = ((double)x / 100)-0.03;
                        height = (double)abs(y-h) / 100;
                        break;
                    }
                }
                if (radius != 0)
                out << radius << space << height << std::endl;
                radius = 0;
            }
            out.close();
        }
        void writeVertices();
    };

    class Terrain : public Mesh
    {
    private:
        shared_ptr< G3D::Image> image;
        float terrain_px_per_m;
        double segWidth, segHeight, maxHeight;
        char *terrainHeightPath;
        void calculateHeightField()
        {
            int h = image->height(), w = image->width();
            float totWidth = (1 / terrain_px_per_m) * w; //meters
            float totHeight = (1 / terrain_px_per_m) * h;
            segWidth = totWidth / col; //meters
            segHeight = totHeight / row;
            int resolw = floor(terrain_px_per_m * segWidth);
            int resolh = floor(terrain_px_per_m * segHeight);//pixels per seg

            terrainHeightPath = "D:\\WORKING FOLDER\\3D-Graphics-Shaders\\Codex-Graphics\\MeshProj\\data-files\\model\\color.txt";
            float height = 0;
            out.open(terrainHeightPath);
            for (int i = 0; i <= row; i++)
            {
                for (int j = 0; j <= col; j++)
                {
                    int y = i == row ? h-1 : resolh * i;
                    int x = j == col ? w-1 : resolw * j;

                    //following the row x col convention
                    Point2int32 pos(y,x);
                    Color4 color;
                    image->get(pos, color);
                    height = abs(1 - color.r);
                    out << height << space;
                }
            }
            out.close();
        }
    public:
        Terrain(char* m, char* fp, int c, int r, G3D::String m_image, float mr, float my) : Mesh(m, fp, c, r),terrain_px_per_m(mr),maxHeight(my)
        {
            image = G3D::Image::fromFile(m_image);
            calculateHeightField();
        };

    public:
        void writeDimensions();
        void writeVertices();
        void writeTriangles();
    };
}