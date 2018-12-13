def nbors(pt):
    x,y=pt
    yield x+1,y
    yield x+1,y+1
    yield x+1,y-1
    yield x-1,y
    yield x-1,y+1
    yield x-1,y-1
    yield x,y+1
    yield x,y-1
    
def advance(brd):
    nbrd=set()
    recalc=brd | {xy for pt in brd for xy in nbors(pt)}
    for pt in recalc:
        ct=sum( n in brd for n in nbors(pt) )
        if ct==3 or (ct==2 and pt in brd):
            nbrd.add(pt)
    return nbrd
    
gldr=set([(0,0),(1,0),(2,0),(0,1), (1,2)])
for i in range(100):
    gldr=advance(gldr)
print(gldr)
