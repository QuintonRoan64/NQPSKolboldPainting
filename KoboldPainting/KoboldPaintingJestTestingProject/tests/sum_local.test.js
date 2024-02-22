"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const sum_1 = require("../sum");
test('Sum function should return the correct sum of two numbers', () => {
    expect((0, sum_1.Sum)(2, 3)).toBe(5);
    expect((0, sum_1.Sum)(-5, 10)).toBe(5);
    expect((0, sum_1.Sum)(0, 0)).toBe(0);
});
//# sourceMappingURL=sum_local.test.js.map