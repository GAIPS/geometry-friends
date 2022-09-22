import environment
import json

class JsonManager:
	def initEnvironment(self, circleCharacter, rectangleCharacter, blackObstacles, yellowObstacles, greenObstacles, collectibles, area):
		data = json.loads(circleCharacter)
		c = environment.CircleCharacter(data["X"], data["Y"],  data["VelocityX"], data["VelocityY"], data["Radius"])
		data = json.loads(rectangleCharacter)
		r = environment.RectangleCharacter(data["X"], data["Y"],  data["VelocityX"], data["VelocityY"], data["Height"])
		data = json.loads(blackObstacles)
		blackObs = []
		for el in data:
			blackObs.append(environment.BlackObstacle(el["X"], el["Y"], el["Width"], el["Height"]))
		data = json.loads(yellowObstacles)
		yellowObs = []
		for el in data:
			yellowObs.append(environment.YellowObstacle(el["X"], el["Y"], el["Width"], el["Height"]))
		data = json.loads(greenObstacles)
		greenObs = []
		for el in data:
			greenObs.append(environment.GreenObstacle(el["X"], el["Y"], el["Width"], el["Height"]))
		data = json.loads(collectibles)
		cols = []
		for el in data:
			cols.append(environment.Collectible(el["X"], el["Y"]))
		data = json.loads(area)
		ar = environment.Area(data["Top"], data["Left"],  data["Width"], data["Height"])
		env = environment.Environment(c, r, blackObs, yellowObs, greenObs, cols, ar)
		print(env.logEnvironment())
		return env

	def updateEnvironment(self, agent, circleCharacter, rectangleCharacter, collectibles):
		data = json.loads(circleCharacter)
		c = environment.CircleCharacter(data["X"], data["Y"],  data["VelocityX"], data["VelocityY"], data["Radius"])
		data = json.loads(rectangleCharacter)
		r = environment.RectangleCharacter(data["X"], data["Y"],  data["VelocityX"], data["VelocityY"], data["Height"])
		data = json.loads(collectibles)
		cols = []
		for el in data:
			cols.append(environment.Collectible(el["X"], el["Y"]))
		agent.env.updateEnvironment(c, r, cols)
		print(agent.env.logEnvironment())
