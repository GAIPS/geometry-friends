import numpy as np
from enum import Enum

'''Character Moves'''
class Moves(Enum):
	NO_ACTION = 0
	ROLL_LEFT = 1
	ROLL_RIGHT = 2
	JUMP = 3
	GROW = 4
	MOVE_LEFT = 5
	MOVE_RIGHT = 6
	MORPH_UP = 7
	MORPH_DOWN = 8

'''Agent Class'''
class Agent:
	def __init__(self, name, env):
		self.name = name
		self.env = env
		self.currentAction = -1
	
	#TODO: messages between agents? 

'''Circle Agent Class'''
class CircleAgent(Agent):
	def __init__(self, name, env):
		super().__init__(name, env)
		self.possibleMoves = [Moves.ROLL_LEFT.value, Moves.ROLL_RIGHT.value, Moves.JUMP.value]
		self.lenMoves = len(self.possibleMoves)
	
	def randomAction(self):
		self.currentAction = np.random.randint(0, self.lenMoves)
		
	def executeAction(self):
		self.randomAction()

'''Rectangle Agent Class'''
class RectangleAgent(Agent):
	def __init__(self, name, env):
		super().__init__(name, env)
		self.possibleMoves = [Moves.MOVE_LEFT.value, Moves.MOVE_RIGHT.value, Moves.MORPH_UP.value, Moves.MORPH_DOWN.value]
		self.lenMoves = len(self.possibleMoves)
		self.prevX = 0
		self.state = "GO"
	
	def randomAction(self):
		self.currentAction = np.random.randint(0, self.lenMoves)
	
	def closestCollectible(self):
		#find closest collectible
		dist = []
		rCharArr = np.array((self.env.rectangleCharacter.x, self.env.rectangleCharacter.y))
		for c in self.env.collectibles:
			cArr = np.array((c.x, c.y))
			dist.append(np.linalg.norm(rCharArr - cArr))
		minC = np.argmin(dist)
		return self.env.collectibles[minC]
	
	def greedyAction(self):
		closest = self.closestCollectible()
		currentX = self.env.rectangleCharacter.x
		if (abs(self.prevX - currentX) < 0.01): #cant move > MORPH_DOWN
			self.currentAction = 3
		else: #can move
			if closest.x - self.prevX > 100:
				self.currentAction = 1
			elif closest.x - self.prevX < -100:
				self.currentAction = -1
			else:
				self.currentAction = -1

		self.prevX = currentX

	def executeAction(self):
		self.greedyAction()
		#self.randomAction()
