#include "pch.h"
#include "SetGhostEffectBrick.h"
#include "Script.h"
#include "Object.h"
#include "Interpreter.h"

using namespace ProjectStructure;

SetGhostEffectBrick::SetGhostEffectBrick(FormulaTree *transparency, Script* parent) :
	Brick(TypeOfBrick::SetGhostEffectBrick, parent),
	m_transparency(transparency)
{
}

void SetGhostEffectBrick::Execute()
{
	m_parent->GetParent()->SetTransparency((Interpreter::Instance()->EvaluateFormulaToFloat(m_transparency, GetParent()->GetParent()) / 100.0f));
}