from osgeo import gdal
    
options_list = [
    '-ot Byte',
    '-of JPEG',
    '-b 1',
    '-scale'
]           

options_string = " ".join(options_list)
    
gadl.Translate(
    'save_world.png',
    'world.tif',
    options=options_string
)