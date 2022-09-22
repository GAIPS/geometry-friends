'''Environment Class (Obstacles, Characters, Collectibles)'''
class Environment:
	def __init__(self, circleCharacter, rectangleCharacter, blackObstacles, yellowObstacles, greenObstacles, collectibles, area):
		self.circleCharacter = circleCharacter
		self.rectangleCharacter = rectangleCharacter
		self.blackObstacles = blackObstacles
		self.yellowObstacles = yellowObstacles
		self.greenObstacles = greenObstacles
		self.collectibles = collectibles
		self.area = area
		
	def updateEnvironment(self, circleCharacter, rectangleCharacter, collectibles):
		self.circleCharacter = circleCharacter
		self.rectangleCharacter = rectangleCharacter		
		self.collectibles = collectibles		

	def logEnvironment(self):
		logEnv = self.circleCharacter.logCharacter() + self.rectangleCharacter.logCharacter()
		for bO in self.blackObstacles:
			logEnv += bO.logObstacle()
		for yO in self.yellowObstacles:
			logEnv += yO.logObstacle()
		for gO in self.greenObstacles:
			logEnv += gO.logObstacle()		
		for c in self.collectibles:
			logEnv += c.logCollectible()
		logEnv += self.area.logArea()
		return logEnv

'''Game Area Class'''
class Area:
	def __init__(self, top, left, width, height):
		self.top = top
		self.left = left
		self.width = width
		self.height = height

	def logArea(self):
		return "Area - " + "top: " + str(self.top) + ", left: " + str(self.left) + ", width: " + str(self.width) + ", height: " + str(self.height) + "\n"

'''Collectible Class'''
class Collectible:
	def __init__(self, x, y):
		self.x = x
		self.y = y

	def logCollectible(self):
		return "Collectible - " + "x: " + str(self.x) + ", y: " + str(self.y) + "\n"

'''Obstacle Class (Black, Green, Yellow)'''
class Obstacle:
	def __init__(self, x, y, width, height):
		self.x = x
		self.y = y
		self.width = width
		self.height = height

	def logObstacle(self):
		return "Obstacle - " + "x: " + str(self.x) + ", y: " + str(self.y) + ", width: " + str(self.width) + ", height: " + str(self.height) + "\n"

#Collision with circle and rectangle
class BlackObstacle(Obstacle):
	def __init__(self, x, y, width, height):
		super().__init__(x, y, width, height)

	def logObstacle(self):
		return "Black " + super().logObstacle()

#Collision with yellow circle
class GreenObstacle(Obstacle):
	def __init__(self, x, y, width, height):
		super().__init__(x, y, width, height)

	def logObstacle(self):
		return "Green " + super().logObstacle()

#Collision with green rectangle
class YellowObstacle(Obstacle):
	def __init__(self, x, y, width, height):
		super().__init__(x, y, width, height)

	def logObstacle(self):
		return "Yellow " + super().logObstacle()

'''Character Class (Circle or Rectangle)'''
class Character:
	def __init__(self, x, y, velX, velY):
		self.x = x
		self.y = y
		self.velX = velX
		self.velY = velY

	def logCharacter(self):
		return "Character - " + "x: " + str(self.x) + ", y: " + str(self.y) + ", velX: " + str(self.velX) + ", velY: " + str(self.velY)
class CircleCharacter(Character):
	def __init__(self, x, y, velX, velY, radius):
		super().__init__(x, y, velX, velY)
		self.radius = radius

	def logCharacter(self):
		return "Circle " + super().logCharacter() + ", radius: " + str(self.radius) + "\n"

class RectangleCharacter(Character):
	def __init__(self, x, y, velX, velY, height):
		super().__init__(x, y, velX, velY)
		self.height = height

	def logCharacter(self):
		return "Rectangle " + super().logCharacter() + ", height: " + str(self.height) + "\n"
