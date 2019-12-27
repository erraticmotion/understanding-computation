require_relative 'do_nothing'
require_relative 'if'
require_relative 'sequence'

class While < Struct.new(:condition, :body)
  def reducible?
    true
  end

  def reduce(environment)
    [If.new(condition, Sequence.new(body, self), DoNothing.new), environment]
  end

  def to_s
    "while (#{condition}) { #{body} }"
  end
  
  def inspect
    "«#{self}»"
  end
end