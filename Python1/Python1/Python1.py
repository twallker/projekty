#cv2.imshow("tytuł okna", img) # stworzenie okna z obrazkiem
#cv2.waitKey()                 # ważna funkcja!!!
#cv2.destroyAllWindows()       # zamknięcie wszystkich okien
#Funkcja waitKey() odpowiada za obsługę okienek (ich rysowanie/odświeżanie/interakcję z użytkownikiem). Funkcja zwraca kod klawisza który został naciśnięty.

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