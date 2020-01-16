# 3D Grphics Personal Projects

Combine Meshes of Child Objects into one Single Mesh and retain their textures. <br><br>
Add the script to the parent gameobject(this game object has to be an empty gameobject).
The children of the these game objects will be found and combined with a call to *CombineMeshes()* method.<br>
The __CombinePerVertex.cs__ and __TextureArray.shader__ files go in conjunction.<br>
The shader should be used to create a material that is applied to the empty parent game obejct from above. Once the script is run, the texure array is created and and the uv2.x value is used as the array index for mapping the textures with their appropriate objects after the mesh combine method is implemented.
