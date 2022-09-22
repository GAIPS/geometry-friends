import jsonManager
import agent
import pickle
import sys

def pickleWrite(filename, obj):
	file = open(filename, "wb")
	pickle.dump(obj, file)
	file.close()

def pickleLoad(filename):
	file = open(filename, "rb")
	obj = pickle.load(file)
	file.close()
	return obj

def main():
	if (sys.argv[1] == "initRectangleAgent"):
		jsonMng = jsonManager.JsonManager()
		env = jsonMng.initEnvironment(sys.argv[2], sys.argv[3], sys.argv[4], sys.argv[5], sys.argv[6], sys.argv[7], sys.argv[8])
		a = agent.RectangleAgent("Rectangle", env)
		pickleWrite("../../python/rectangle.pickle", a)
	elif (sys.argv[1] == "initCircleAgent"):
		jsonMng = jsonManager.JsonManager()
		env = jsonMng.initEnvironment(sys.argv[2], sys.argv[3], sys.argv[4], sys.argv[5], sys.argv[6], sys.argv[7], sys.argv[8])
		a = agent.CircleAgent("Circle", env)
		pickleWrite("../../python/circle.pickle", a)
	elif (sys.argv[1] == "runRectangleAgent"):
		jsonMng = jsonManager.JsonManager()
		a = pickleLoad("../../python/rectangle.pickle")
		jsonMng.updateEnvironment(a, sys.argv[2], sys.argv[3], sys.argv[4]) #update environment
		a.executeAction() #execute action
		pickleWrite("../../python/rectangle.pickle", a)
		print(a.currentAction) #do not remove this print
	elif (sys.argv[1] == "runCircleAgent"):
		jsonMng = jsonManager.JsonManager()
		a = pickleLoad("../../python/circle.pickle")
		jsonMng.updateEnvironment(a, sys.argv[2], sys.argv[3], sys.argv[4]) #update environment
		a.executeAction() #execute action
		pickleWrite("../../python/circle.pickle", a)
		print(a.currentAction) #do not remove this print
	
if __name__ == "__main__":
	main()
