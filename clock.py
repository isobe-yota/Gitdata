from turtle import *
import datetime
import turtle
t1=Turtle()#秒針
t2=Turtle()#分針
t3=Turtle()#時針
t1.color('red')
t2.color('blue')
t3.color('green')
t1.speed=t2.speed=t3.speed=100
t1len=100
t2len=50
t3len=25
timeCount=0

def Init(angle1,angle2,angle3):
    t1.setheading(90)
    t2.setheading(90)
    t3.setheading(90)
    t1.right(angle1)
    t2.right(angle2)
    t3.right(angle3)
    t1.forward(t1len)
    t2.forward(t2len)
    t3.forward(t3len)
    

def Reset(t):
    t.clear()
    t.pu()
    t.setposition(0,0)
    t.pd()
pu()
goto(0,-150)
pd()
circle(150)
nowTime = datetime.datetime.now()
oldTime=nowTime
t1angle=nowTime.second*6
t2angle=nowTime.minute*6
t3angle=nowTime.hour*30
Reset(t1)
Reset(t2)
Reset(t3)
Init(t1angle,t2angle,t3angle)
while(timeCount<180):
    nowTime = datetime.datetime.now()
    if nowTime.second!=oldTime.second:
        timeCount+=1
        Reset(t1)
        t1angle=(nowTime.second-oldTime.second)*6
        t1.right(t1angle)
        t1.forward(t1len)
    
    if nowTime.minute!=oldTime.minute:
        Reset(t2)
        t2angle=(nowTime.minute-oldTime.minute)*6
        t2.right(t2angle)
        t2.forward(t2len)
    
    if nowTime.hour!=oldTime.hour:
        Reset(t3)
        t3angle=(nowTime.hour-oldTime.hour)*30
        t3.right(t3angle)
        t3.forward(t3len)
    oldTime=nowTime
        





