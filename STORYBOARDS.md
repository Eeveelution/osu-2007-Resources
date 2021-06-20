Storyboard format

Every line of a storyboard will have these 2 numbers

0,0

The first number is the type<br>
The second number is the time it occurs at<br>
The rest depends on the type of action<br>

TYPE 0: Basic image, displays an image<br>
0,0,"dango.jpg"

TYPE 1: Play a video, plays a video in the background<br>
1,0,"clannad_ed_01.avi"

TYPE 2: Break<br>
  start   end<br>
2,113499,156200<br>

TYPE 3: Background color, the color to tint the background to, in RGB format<br>
     R   G   B<br>
3,0,163,162,255<br>
