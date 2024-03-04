#import cv2

print("Hello world")

#img = cv2.imread("c:/OpenCV2.3.1/samples/c/lena.jpg")
#wczytanie przykładowego obrazka

#img.shape
#wymiary tablicy img - w przypadku obrazków kolorowych trzeci wymiar reprezentuje kolory w przestrzeni BGR

#cv2.imshow("tytuł okna", img) # stworzenie okna z obrazkiem
#cv2.waitKey()                 # ważna funkcja!!!
#cv2.destroyAllWindows()       # zamknięcie wszystkich okien
#Funkcja waitKey() odpowiada za obsługę okienek (ich rysowanie/odświeżanie/interakcję z użytkownikiem). Funkcja zwraca kod klawisza który został naciśnięty.

#img = zeros((100,100,3), uint8)
#img[10,10,0] = 255 # Blue
#img[10,10,1] = 255 # Green
#img[10,10,2] = 255 # Red

#img[20,20] = (0, 255, 255) # kolor żółty

#cv2.imshow("okno", img)
#cv2.waitKey()
#cv2.destroyAllWindows()


import cv2 as cv
import sys
import numpy as np
img = cv.imread(cv.samples.findFile("starry_night.jpg"))
if img is None:
    sys.exit("Could not read the image.")
cv.imshow("Display window", img)
k = cv.waitKey(0)

img = np.zeros((150,150,3), np.uint8)
img[10,10,0] = 255 # Blue
img[10,10,1] = 255 # Green
img[10,10,2] = 255 # Red

img[20,20] = (0, 255, 255) # kolor żółty

cv.imshow("okno", img)
cv.waitKey()
cv.destroyAllWindows()
#if k == ord("s"):
#    cv.imwrite("starry_night.png", img)