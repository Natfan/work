var rectHeight;
var width;
var height;
var cloudsX = [ 020, 120, 220, 320, 420, 520, 620, 720, 820, 920 ];
var cloudsY = [ 020, 050, 080, 050, 020, 030, 050, 070, 040, 010 ];
var base;
var counter;

function setup() {
	width = 720;
	height = 480;
	createCanvas(width, height);
	rectHeight = 100;
    base = 50;
    counter = 0;
}


function draw() {
    clear();
	fill(0, 128, 0);
	noStroke();
	background(113, 116, 210);
	rect(0, 400, width, rectHeight);
    for (var i = 0; i < cloudsX.length; i++) {
        cloud(cloudsX[i], cloudsY[i]);
        cloudsX[i]++;
        if (cloudsX[i] > width) {
            cloudsX[i] = cloudsX[i] - width;
        }
    }
    if (counter < (base * 10)) {
       counter++;
       console.log(counter);
    }
    house();
}

function house() {
    stroke (0, 0, 0); //black
    if (counter > base) {
        line(150, 400, 250, 400); // bottom
    }
    if (counter > base * 2) {
        line(150, 300, 150, 400); // left
    }
    if (counter > base * 3) {
        line(150, 300, 250, 300); // top
    }
    if (counter > base * 4) {
        line(250, 300, 250, 400); // right
    }
    if (counter > base * 5) { 
        line(150, 300, 200, 240); // left roof
    }
    if (counter > base * 6) { 
        line(250, 300, 200, 240); // right roof
    }
    if (counter > base * 7) {
        line(185, 350, 185, 400); // left door
    }
    if (counter > base * 8) {
        line(185, 350, 215, 350); // top door
    }

    if (counter > base * 9) {
        line(215, 350, 215, 400); // right door
    }
}

function cloud(cloudX, cloudY) {
    stroke(255, 255, 255);
    fill(255, 255, 255);
    ellipse(cloudX + 35, cloudY + 20, 50, 40);
    ellipse(cloudX + 55, cloudY + 30, 60, 30);
    ellipse(cloudX + 60, cloudY + 20, 20, 20);
    ellipse(cloudX + 15, cloudY + 30, 30, 20);  
    ellipse(cloudX + 35, cloudY + 35, 40, 30);
}
