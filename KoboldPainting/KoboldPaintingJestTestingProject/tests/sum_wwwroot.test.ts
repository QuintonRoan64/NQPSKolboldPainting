import { Sum } from '../../KoboldPainting/wwwroot/ts/sum';

test('Sum function should return the correct sum of two numbers', () => {
    expect(Sum(2, 3)).toBe(5);
    expect(Sum(-5, 10)).toBe(5);
    expect(Sum(0, 0)).toBe(0);
});
