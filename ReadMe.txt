Scene의 game Scene이 기본 씬입니다.

해당 프로젝트에서 만든 모델은 Assets - model에 있으며
씬에서 Environment - plane - behavior parameter - model에 넣어 테스트할 수 있습니다.

또한 이 파일이 있는 디렉토리에서 mlagents 실습이 가능하며
보고서에 있는 그대로 진행하시면 됩니다.

참고로 model에는 Best, NotFoundBest, NotFoundEnter 3개가 있으며
Best에 대해서는 
plane - sensor - Ray Perception Sensor 2D의 Stacked Raycasts를 3으로

나머지 2개의 경우에는
plane - sensor - Ray Perception Sensor 2D의 Stacked Raycasts를 1로

설정하여야 동작이 가능합니다.