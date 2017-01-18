# Unit XXX Assignment II
*By Nathan Windisch*
## Task I: Guide With Screenshots

### PIII: Editing and Manipulating Images
For this task I decided to use a mix of GIMP and Pixlr, both of which are free image editing tools.

In the following image I was creating a file.
![][PIII Create]


Below you can see me opening an image which I took earlier.
![][PIII Open]


Here I am selecting part of the image.
![][PIII Select]


I am selecting part of the image, copying it and pasting it to another location in this image.
![][PIII CopyPaste]


Here I used the blend tool to make the benches stand out. Sadly the blur tool malfunctioned, but this was the result.
![][PIII Blend]


In this image I am attempting to remove one of the benches from another image. Again, I used too much of the tool, resulting in a blur instead of the bench being removed.
![][PIII Heal]


Here I am selecting the part of the image to be cloned.
![][PIII Clone 1]
And here I am pasting the clone into a different part of the image.
![][PIII Clone 2]


In this image I am using the burn tool.
![][PIII Burn]


Here I am changing the hue and saturation of the image.
![][PIII Hue]


In this image I have added a layer with hand drawn text on it.
![][PIII Layer 1]
And in this image I am moving the layer.
![][PIII Layer 2]

In the following image I am using the liquefy tool to start to make the foreground standout from the background. Sadly, I used too much and it didn't work out.
![][PIII Liquefy]

### MII: Justify the Use of Software, Tools, File Format, Image Resolution & Colour Depth for Use of Creating Images
The correct software must be used when creating images. If the software is too basic, such as Microsoft Paint, then the graphic artist will not be able to create the best image that they can. If the software is too advanced, such as Adobe Photoshop, then the graphic artist may be overwhelmed with the amount of tools that they can use but do not have the correct skills to use them, resulting in a badly created image. This means that the graphic artist should use software that they feel comfortable with, so that they can create the best work with the tools that they know.

On the subject of tools, the graphics designer should attempt to learn a new software every few months or years to keep up to date with the latest trends. This means that a percentage of the designer's time will be spend studying new software layouts and understanding the best way to use specific tools. This means that the graphics that the designer creates will be able to create and edit better looking images easier than before, using the new tools and concepts that they have acquired.

The designer will need to choose what formats to use. If they are working with logos and text based images, they may wish to create the image using vector graphics and the SVG format would be perfect for this, as the final product can be resized to any size without any distortion or loss of quality. If the designer is making graphics for websites such as background or editing images, then they may wish to use raster graphics, meaning that it uses pixels rather than lines. This allows for much more precise editing, but prevents the image from being resized too much, due to distortion. The final file format that the designer should use will probably be JPEG, due to it's excellent compression, or PNG, due to it's wide use. BMP or PSD could be used, but only if the designer believes that the image shall be edited later, the former keeps the original data and the latter keeps all of the metadata, allowing for easier editing.

Colour depth is important as it is the ensures how many colours are going to be used. For high quality, high definition images such as photographs, I would recommend using 32 Bit color depth as it has the most data and colour variety.


### DII: Discuss the Impact that File Format, Compression Techniques, Image Resolution and Colour Depth Have File Size and Image Quality

One way that file size can be affected is if they use different types of compression techniques are used. An example of this is if an example image is saved using the JPEG compression standard, then it will use only 10MB of data as it is a "compressed" image, it contains no additional data that can be used to edit the file later on. To put this in terms of computer programming, the final version of the code is what the programmer has actually typed, whereas the debug version of the program has many more features that would be useful to the developer, such as logging and comments. This means that the debug file is much bigger than the final compiled code is much smaller and easier to distribute. This is very similar why most final images stored on the Internet are JPEG or PNG files, as it causes smaller files to be used, meaning that it is easier to download the images when accessing the web page.

One of the main factors in why different image compression techniques are used is because different file formats produce different output results. For instance, this ![][DII Cow Image Link] image was originally 4.4MB as a JPEG file. Later, it was saved as a TIFF file with LZW compression and the file size went up to 10.4MB. When saved as a Flat PSD file the size went up to 30.7MB, and when saved as a TIFF file with no compression, the file size went up to 37.3MB. The reason why the file size by a factor of ~8.6 was because so many more extra details were being added to the image, such as layer information, meta data and more. In fact, when taking the Flat PSD file, which is 30.7MB, and just renaming the background layer to something different can increase the file size to 61.7MB, over double the original size. This is due to the fact that so much more data is being added to the image file, while the actual output remains the same. The PSD files are for the artist to use, and the JEG files are for the consumers to use, as a rule of thumb.

Another way that file size can be affected is by image resolution. If the image resolution is lower, the file size will be smaller but the image may become pixelated and harder to view at larger sizes. If the image resolution is larger, the image will be much easier to see and will have more details, but the file size may be much larger. This is because the more pixels there are, the larger the file is due to the larger amounts of data being stored.

This is because most screens have a large number of pixels, such as 1920x1080 - the current HD standard for  monitors. On a 1920x1080 screen there are a total of 2,073,600 pixels on the  entire screen. This means that an image which is 128x128 pixels may look good at a small size, where each pixel of the image takes up one pixel on the screen, but if the image is resized so that it is 10 times it's original size, it means that a pixel in the image that was meant for one pixel on the screen could be occupying 10 'real' pixels, meaning that the image becomes distorted and blurred.

Colour depth can also affect the size of a file. Colour depth is the maximum amount of colours  that can appear in an image. The larger the number of colours, the more realistic an image can be. There are a few types of colour depth, and I shall list them from lowest to the highest.

#### Monochrome
Monochrome is the lowest form of colour depth as it only needs to tell the rendering program if the pixel is on or off, where *on* is white and *off* is black. This means that each pixel is only a bit in size, or 8 pixels is one byte in size.

#### Greyscale
Greyscale uses one byte per pixel, as each byte can be a unique value going up to 256. The renderer transfers these numbers into the amount of grey in an image, meaning that it looks more like an old "black and white" image with many different shades of grey.

#### Paletted
While greyscale and paletted can look very similar on the surface, the main difference is that palleted stores a new colour for each value, whereas greyscale only creates a new grey colour from the data. This means that you can have an image with up to 256 colours. The major drawback of this is that it has to store a palette of colours with it, so that the renderer has a reference point. GIF files are a variation of this and only the amount of colours in a pallet that are needed, whereas default palleted requires all 256 colours, even if the image doesn't use them.

#### 16 Bit
16 Bit, or High Colour, uses two bytes to store each pixel's information. One of the bytes is used for the colour that the pixel will be, and the other will be used to store the shade. This means that there is a grand total of 65,536 (256^2\) colours.

#### 24 Bit
24 Bit colour is one of the most common methods of image storage. It stores an individual byte for each colour of a pixel, storing Red, Green, and Blue, meaning that it uses up three bytes instead of two. This means that it can store 16,777,216 (256^3\) colours. This means that it can generate very realistic photos, but it can take up lots of space for large files.

#### 32 Bit
32 Bit, or True Colour, uses a similar principal as 24 Bit, in that it stores Red, Green and Blue values for images. The main difference is that it also stores the transparency of a pixel. This means that it can store 4,294,967,296 (256^4\) unique colours, taking up four bytes of space per pixel.

File formats can also affect image quality. For instance, JPEG is a "lossy" format, meaning that it compresses the image to save space. The more the file is compressed, the more "artifacts" appear. Artifacts are are distortion or compression in an image. This means that the less compression used, the more details the image will be. This makes it good for photographs and high quality images that do not need to be resized or edited again.

Another file type is BMP, which is uncompressed. This means that the image is in full quality, producing the best results at the cost of a large file size.

SVG files are vector based images, which means that instead of each individual pixel being stored, lines are stored instead. This means that the image can be resized to as large or as small as needed, without any distortion or blur. This is good for logos and images with small amounts of data, such as text, as they can be stored as a small file and the size can be changed on the fly.

Compression techniques can affect image quality by reducing the amount of data that an image stores. It does this by shortening the amount of data that a line takes up, by merging pixels with the same or similar colours to create one long pixel, resulting in less storage being taken up. While this is a good idea for the final image, it is not such a good idea for image which are still being worked on in a production environment. If the compression technique that is used is a bad one, it may cause the image to look different from it's original form. The best type of compression technique would be one that reduces file size without changing how the image looks at all.

Image resolution can affect image quality in that it can allow for higher amount of pixels to be attributed to an image. This means that there will be a distinct increase in quality if there are more pixels being used in an image, due to the fact that more data will be able to be shown on the screen. If an image is eight pixels by eight pixels, then the image will not be a very high quality and may be considered blurry and distorted if magnified to a larger resolution. On the flip side, if an image is 1000 pixels by 1000 pixels in size, the image will only really be able to be displayed on screens with a resolution of 1000x1000 or more, such as 1920x1080 - the current HD standard. If the screen is lower than 1000 pixels high or wide, then the image may be displayed incorrectly, causing blurryness and artifacts to be created. A screen resolution which could cause this is 1080x720, a HD standard which has been superseded by 1080p.


Colour depth also can affect image quality. For instance, if a black-and-white colour depth is used, then the image will be monochromatic but it will be a very small file size. If you decide to use 32 Bit True Colour then the image will be the best quality with 4,294,967,296 different colour to choose from, but the file size will be very large, even for a small file. For this reason I would use a 24 bit colour depth scheme, such as RGB, HSV, CIE or CMYK, as this gives you a massive amount of colours, without an overwhelming amount of extra colours that may never even be used.

## Task II: Poster with Original Graphic Images

### PIV: Create Original Images
The following is my poster that I created for UTC Reading. I updated it and worked on it after gaining feedback, as can be seen in PV. I used three of my own images, being the background, the computers on the left and the programming on the right.
![][PIV Poster]

### PV: Modify Images Due To User Feedback
I got feedback from my one of my classmates and he gave me the following points:
* The editing is sloppy.
* The image should be more vibrant.
* The text should be clearer.
* More information about the courses should be added.

The following image is my final product after editing:
![][PV Poster]

I shall now go through the points and assess the changes that I performed.

The editing was sloppy. The image that were pasted in felt disjointed and out of place. To solve this, I decided to create a border around the images to make them feel more self contained and standardized.

To make the poster more vibrant, I changed the brightness and saturation of the image to make the image feel more alive and sunny, whereas in reality it was taken on a cold Winter day.

I make the text clearer by making it a sky blue colour (#00FFFF) to make the text stand out from the background, both of which were previously dark colours. I also added a slight black border to the text to show where it ended to make it easier on the eye.

Finally, I added some brief course descriptions below the course names to ensure that people know what they are getting before they do anymore research into the college. This poster is the first time they see UTC Reading, so they should know what to expect.

[PIII Create]: https://github.com/Natfan/BTEC-IT/blob/master/Unit%20XXX%20-%20Photo%20Editing/Assignment%20II/Pictures/create.png "Creating the image."
[PIII Open]: https://github.com/Natfan/BTEC-IT/blob/master/Unit%20XXX%20-%20Photo%20Editing/Assignment%20II/Pictures/open.png "Opening the image."
[PIII Select]: https://github.com/Natfan/BTEC-IT/blob/master/Unit%20XXX%20-%20Photo%20Editing/Assignment%20II/Pictures/select.png "Selecting the image."
[PIII CopyPaste]: https://github.com/Natfan/BTEC-IT/blob/master/Unit%20XXX%20-%20Photo%20Editing/Assignment%20II/Pictures/copypaste.png "Copying and Pasting the image."
[PIII Blend]: https://github.com/Natfan/BTEC-IT/blob/master/Unit%20XXX%20-%20Photo%20Editing/Assignment%20II/Pictures/blend.png "Blending the image."
[PIII Heal]: https://github.com/Natfan/BTEC-IT/blob/master/Unit%20XXX%20-%20Photo%20Editing/Assignment%20II/Pictures/heal.png "Cloning the image 1."
[PIII Clone 1]: https://github.com/Natfan/BTEC-IT/blob/master/Unit%20XXX%20-%20Photo%20Editing/Assignment%20II/Pictures/clone1.png "Cloning the image 1."
[PIII Clone 2]: https://github.com/Natfan/BTEC-IT/blob/master/Unit%20XXX%20-%20Photo%20Editing/Assignment%20II/Pictures/clone2.png "Cloning the image 2."
[PIII Burn]: https://github.com/Natfan/BTEC-IT/blob/master/Unit%20XXX%20-%20Photo%20Editing/Assignment%20II/Pictures/burn.png "Burning the image."
[PIII Hue]: https://github.com/Natfan/BTEC-IT/blob/master/Unit%20XXX%20-%20Photo%20Editing/Assignment%20II/Pictures/hue.png "Changing the Hue and Saturation image."
[PIII Layer 1]: https://github.com/Natfan/BTEC-IT/blob/master/Unit%20XXX%20-%20Photo%20Editing/Assignment%20II/Pictures/layer1.png "Editing Layer 1 of the image."
[PIII Layer 2]: https://github.com/Natfan/BTEC-IT/blob/master/Unit%20XXX%20-%20Photo%20Editing/Assignment%20II/Pictures/layer2.png "Editing Layer 2 of the image."
[PIII Liquefy]: https://github.com/Natfan/BTEC-IT/blob/master/Unit%20XXX%20-%20Photo%20Editing/Assignment%20II/Pictures/liquefy.png "Liquefying the image."

[PIV Poster]: https://github.com/Natfan/BTEC-IT/blob/master/Unit%20XXX%20-%20Photo%20Editing/Assignment%20II/Posterv1.bmp

[PV Poster]: https://github.com/Natfan/BTEC-IT/blob/master/Unit%20XXX%20-%20Photo%20Editing/Assignment%20II/Posterv2.bmp

[DII Cow Image Link]: http://www.coloredbean.com/userfiles/image/news_23_3.jpg "See http://www.coloredbean.com/blog/23/Impact-of-File-Format-on-File-Size.htm for more information."
